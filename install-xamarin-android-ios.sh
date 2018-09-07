XAMARIN_IOS_VERSION=11.10.1.178
XAMARIN_ANDROID_VERSION=8.3.0-19

installpkg() {
    sudo installer -pkg $1 -target /
}

# install Android SDK
brew tap caskroom/cask
brew cask install android-sdk > brew.cask.install.android-sdk.log

mkdir ~/.android
touch ~/.android/repositories.cfg

yes | $ANDROID_SDK_PATH/tools/bin/sdkmanager "build-tools;27.0.1" "platforms;android-27" "platform-tools" > sdkmanager.log

# install Xamarin.IOS
wget https://dl.xamarin.com/MonoTouch/Mac/xamarin.ios-$XAMARIN_IOS_VERSION.pkg
installpkg xamarin.ios-$XAMARIN_IOS_VERSION.pkg > installpkg.xamarin.ios.log

# install Xamarin.Android
wget https://dl.xamarin.com/MonoforAndroid/Mac/xamarin.android-$XAMARIN_ANDROID_VERSION.pkg
installpkg xamarin.android-$XAMARIN_ANDROID_VERSION.pkg > installpkg.xamarin.android.log
