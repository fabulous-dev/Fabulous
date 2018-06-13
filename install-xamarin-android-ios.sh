XAMARIN_IOS_VERSION=11.10.1.178
XAMARIN_ANDROID_VERSION=8.3.0-19

installpkg() {
    sudo installer -pkg $1 -target /
}

# install Android SDK
brew tap caskroom/cask
brew cask install android-sdk

mkdir ~/.android
touch ~/.android/repositories.cfg

# pipe the output of sdkmanager to /dev/null because I can't find any documentation on log verbosity
# and hitting the following error in travis
#
# ```
# The log length has exceeded the limit of 4 MB (this usually means that the test suite is raising the same exception over and over).

# The job has been terminated
# ```
yes | $ANDROID_SDK_PATH/tools/bin/sdkmanager "build-tools;27.0.1" "platforms;android-25" "platform-tools" > /dev/null

# install Xamarin.IOS
wget https://dl.xamarin.com/MonoTouch/Mac/xamarin.ios-$XAMARIN_IOS_VERSION.pkg
installpkg xamarin.ios-$XAMARIN_IOS_VERSION.pkg

# install Xamarin.Android
wget https://dl.xamarin.com/MonoforAndroid/Mac/xamarin.android-$XAMARIN_ANDROID_VERSION.pkg
installpkg xamarin.android-$XAMARIN_ANDROID_VERSION.pkg
