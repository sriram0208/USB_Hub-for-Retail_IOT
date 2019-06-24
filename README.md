# USB_Hub-for-Retail_IOT
NCR Internship project

Problem Statement : 
  Peripherals for a Point of Sale, are very localized to the implementation, 
  and are hard to switch across the several available POS Solutions. 

Proposed Solution: 
  We could program a Single board micro computer to act as a Smart HUB that 
  will abstract the peripheral specific logic, so that the peripherals can 
  be shared across the Retail POS Solutions. 	
  The idea is that the peripheral would send the data generated to the HUB, 
  and the HUB would transmit the peripheral specific data over IP, in the first stage.
  Several different POS, would only need to talk via IP and use the HUB supplied jar/.
  so to obtain the needed info and perform the needed operation.


Repository structure :
  1)src-folder contains project source files-server side , client side
  2)doc-folder contains documentation of the project
  3)others-folder contains source files during the process of development
