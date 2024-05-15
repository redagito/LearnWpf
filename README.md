# LearnWpf
Projects to learn WPF and MVVM

## NavigationTest
Based on https://www.youtube.com/watch?v=wFzmBZpjuAo

## NavigationTest2
Reimplementation of NavigationTest using MVVM Community Toolkit

## SharingData
Based on https://www.youtube.com/watch?v=umRSp4qB6Tw

## SharingData2
Reimplementation of SharingData using MVVM Community Toolkit

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
* View binds to properties in view model
* View calls commands exposed in ViewModel
* View is notified of updates in ViewModel via INotifyPropertyChanged event

# Resources
Projects are based on several text and video tutorials
* https://www.youtube.com/@_buffer/videos
