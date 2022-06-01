namespace FabulousContacts

open FabulousContacts.Models
open SQLite

module Repository =
    type ContactObject() =
        [<PrimaryKey; AutoIncrement>]
        member val Id = 0 with get, set

        member val FirstName = "" with get, set
        member val LastName = "" with get, set
        member val Email = "" with get, set
        member val Phone = "" with get, set
        member val Address = "" with get, set
        member val IsFavorite = false with get, set
        member val Picture: byte array = null with get, set

    let convertToObject (item: Contact) =
        let obj = ContactObject()
        obj.Id <- item.Id
        obj.FirstName <- item.FirstName
        obj.LastName <- item.LastName
        obj.Email <- item.Email
        obj.Phone <- item.Phone
        obj.Address <- item.Address
        obj.IsFavorite <- item.IsFavorite
        obj.Picture <- item.Picture |> Option.toObj
        obj

    let convertToModel (obj: ContactObject) : Contact =
        { Id = obj.Id
          FirstName = obj.FirstName
          LastName = obj.LastName
          Email = obj.Email
          Phone = obj.Phone
          Address = obj.Address
          IsFavorite = obj.IsFavorite
          Picture = obj.Picture |> Option.ofObj }

    let connect dbPath =
        async {
            let db =
                SQLiteAsyncConnection(SQLiteConnectionString dbPath)

            do!
                db.CreateTableAsync<ContactObject>()
                |> Async.AwaitTask
                |> Async.Ignore

            return db
        }

    let loadAllContacts dbPath =
        async {
            let! database = connect dbPath

            let! objs =
                database.Table<ContactObject>().ToListAsync()
                |> Async.AwaitTask

            let results =
                objs |> Seq.toList |> List.map convertToModel

            do! database.CloseAsync() |> Async.AwaitTask

            return results
        }

    let insertContact dbPath contact =
        async {
            let! database = connect dbPath
            let obj = convertToObject contact

            do!
                database.InsertAsync(obj)
                |> Async.AwaitTask
                |> Async.Ignore

            let! rowIdObj =
                database.ExecuteScalarAsync("select last_insert_rowid()", [||])
                |> Async.AwaitTask

            let rowId = rowIdObj |> int

            do! database.CloseAsync() |> Async.AwaitTask

            return { contact with Id = rowId }
        }

    let updateContact dbPath contact =
        async {
            let! database = connect dbPath
            let obj = convertToObject contact

            do!
                database.UpdateAsync(obj)
                |> Async.AwaitTask
                |> Async.Ignore

            do! database.CloseAsync() |> Async.AwaitTask

            return contact
        }

    let deleteContact dbPath contact =
        async {
            let! database = connect dbPath
            let obj = convertToObject contact

            do!
                database.DeleteAsync(obj)
                |> Async.AwaitTask
                |> Async.Ignore

            do! database.CloseAsync() |> Async.AwaitTask
        }
