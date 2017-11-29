# Kinect Client to IoT Watison IBM Cloud | Bluemix - Hackathon 2017

## Índice
* [Target](https://github.com/vicboma1/clienteKinectIBMCloudIoTWatson/blob/master/README.md#target)
* [Kinect Studio Application Windows](https://github.com/vicboma1/clienteKinectIBMCloudIoTWatson/blob/master/README.md#kinect-studio-application-windows)
* [Tree Map](https://github.com/vicboma1/clienteKinectIBMCloudIoTWatson/blob/master/README.md#tree-map)
* [Formación Universidades](https://github.com/CoEValencia/Hackathon_2017/blob/master/README.md#formación-universidades)
* [Buenas prácticas](https://github.com/CoEValencia/Hackathon_2017/blob/master/README.md#buenas-prácticas)
* Node-RED
  * [Ejemplos](https://github.com/CoEValencia/Hackathon_2017/blob/master/README.md#ejemplos-node-red)
  * [Plantilla](https://github.com/CoEValencia/Hackathon_2017/blob/master/README.md#plantilla-node-red)
* [Miscelaneous](https://github.com/CoEValencia/Hackathon_2017/blob/master/README.md#miscelaneous)
* [Créditos](https://github.com/CoEValencia/Hackathon_2017/blob/master/README.md#créditos)
* [Grupo Slack](https://github.com/CoEValencia/Hackathon_2017/blob/master/README.md#grupo-slack)
* [Presentación de Trabajos](https://github.com/CoEValencia/Hackathon_2017/blob/master/README.md#presentación-de-trabajos-)


## Target

![](https://github.com/CoEValencia/Hackathon_2017/blob/master/assets/target.png)

## Kinect Studio Application Windows
![](https://github.com/vicboma1/StarterKitBluemixHands/blob/master/assets/_starterKitBluemixBodyParts.gif)


## Tree Map

```text
C:.
|   App.config
|   App.xaml
|   App.xaml.cs
|   BodyBasics-WPF.csproj
|   BodyBasics-WPF.sln
|   MainWindow.xaml
|   MainWindow.xaml.cs
|   packages.config
|                   
+---bin
|   +---AnyCPU
|       +---Debug & Release
|       |   |   BodyBasics-WPF.exe
|       |   |   ...
|       |   |   
|       |   +---Dependencies
|                   Settings.json
|                       
+---IBM
|   +---IoT
|           IoTConnection.cs
|           IoTConnectionQueue.cs
|           
+---Images
|       Kinect.ico
|       Logo.png
|       Status.png
|       
+---Json
|       JsonAdapterKinect.cs
|       JsonLoader.cs
|       JsonProperties.cs
|       
+---Kinect
|       KinectBodyPart.cs
|       KinectDataHandler.cs
|       KinectUser.cs
|               
+---packages
|   +---IBMWIoTP.0.2.4.0              
|   +---log4net.2.0.5
|   +---M2Mqtt.4.3.0.0      
|   +---Microsoft.AspNet.WebApi.Client.5.2.3     
|   +---Microsoft.Bcl.1.1.10         
|   +---Microsoft.Bcl.Build.1.0.14
|   +---Microsoft.Net.Http.2.2.29
|   +---Newtonsoft.Json.6.0.4
|   +---System.Net.Http.4.3.3
|           
+---Properties
        
```
@Author: [Victor Bolinches Marin](https://github.com/vicboma1)  

@Documento Principal  [CoEValencia - Hackathon 2017](https://github.com/CoEValencia/Hackathon_2017)
