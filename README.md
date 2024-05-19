# LearnWpf
Projects to learn WPF and MVVM

## NavigationTest
Navigation on single window with navigation bar to switch between mutltiple views

Based on https://www.youtube.com/watch?v=wFzmBZpjuAo

## NavigationTest2
Reimplementation of NavigationTest using MVVM Community Toolkit

## SharingData
Sharing live data between two views using singleton service

Based on https://www.youtube.com/watch?v=umRSp4qB6Tw

## SharingData2
Reimplementation of SharingData using MVVM Community Toolkit

## ThemesTest
Switching between light and dark themes

Based on https://www.youtube.com/watch?v=Zr-pLUt9yEw

## MessageTest
Use messager pub-sub mechanism to send messages between viewmodels

Based on https://learn.microsoft.com/en-us/dotnet/communitytoolkit/mvvm/messenger

## CloseableTest
Close window/view from viewmodel

Based on https://stackoverflow.com/questions/16172462/close-window-from-viewmodel

## LearnWpf.PasswordBox
Use wpf LearnWpf.PasswordBox correctly with mvvm pattern

Based on https://stackoverflow.com/questions/1483892/how-to-bind-to-a-LearnWpf.PasswordBox-in-mvvm

# MVVM
Basic principles
* Model stores data and provides functions to manipulate the data
* Model does NOT reference ViewModel
* Model does NOT reference View
* ViewModel does NOT reference View
* ViewModel exposes data to View via properties
* ViewModel exposes change events to View via INotifyPropertyChanged interface
* ViewModel provides functionality to View via commands
* ViewModel does NOT directly manipulate data
* ViewModel references Model
* ViewModel manipulates data either through functions in Model or additional layer
* View references ViewModel
* View does NOT implement business logic
* View may implement logic ONLY when its purely for UI behavior
* View binds to properties in view model
* View calls commands exposed in ViewModel
* View is notified of updates in ViewModel via INotifyPropertyChanged event

## Responsibilities
Responsibilities for Model, ViewModel and View

Model
* Contains client data
* Contains model object relationships
* Contains computed properties
* Raise change events - implements INotifyPropertyChanged
* Performs validation - implements IDataErrorInfo
* Raise validation error events - implements INotifyDataError

ViewModel
* Exposes data to view for reading and writing
* Handles interaction logic
** Calls to domain layer, data layer, services
** Navigation
** Logic for managing client state

View
* Structure and layout of UI
* Rules for Code behind
** Ideally no code behind (as little as possible)
** Any code that REQUIRES explicit references to UI elements can be put in code behind
** Ideally abstract functionality via interfaces -> see CloseableTest
** Handle controls that do not support MVVM pattern

## View First
* View is constructed first
* ViewModel is constructed and set as DataContext on the View

## ViewModel First
* ViewModel is constructed first
* View is constructed based on ViewModel in UI (DataTemplate) 

# Resources
Projects are based on several text and video tutorials
* https://www.youtube.com/@_buffer/videos
* https://web.archive.org/web/20090413205731/http://karlshifflett.wordpress.com/2008/11/08/learning-wpf-m-v-vm/
* https://learn.microsoft.com/en-us/previous-versions/msp-n-p/hh848246(v=pandp.10)?redirectedfrom=MSDN
* https://learn.microsoft.com/en-us/dotnet/communitytoolkit/mvvm/puttingthingstogether
* https://github.com/mysteryx93/Modern.Net-Tutorial/
* https://github.com/mysteryx93/HanumanInstitute.MvvmDialogs
