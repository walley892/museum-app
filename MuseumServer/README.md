# MusuemAppServer

This folder contains the scripts required to run the server side of the app. 

### Setup

* Run ```npm install```

* Add the following environment variables:

    1. MONGO_URL  as the mongo connection url you'll be using
    2. FILE_HOME  as the root directory where uploaded files live


### Running 

To run ```sudo npm start```.

You should see "Live on 80" output on the terminal. Alternatively, it will be the port your configuration defaults to. 

Go to http://127.0.0.1:80 to access the routes locally. 


(```sudo``` required to save files to server) 