# HMI_WPF-App
Creating a HMI Panel to connect with Siemens S7-1200 PLC and control the Tank level

This project shows an application in WPF framework - HMI Panel which connects to real PLC and can control the Pump and Tank level. 
It is also used to monitor actual values and visualize the process.
To connect with the PLC I use the Sharp7 library. The whole application structure is based on WPF PRISM framework.
It also use Navigation between regions and Autofac as DI container to resolve the services.
