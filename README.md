# Chat application in WAN using C#

This is an upgraded version of the chat application for LAN. We have modified the server functionality; instead of running it on a local host with a UI, you can now host it on a virtual computer and run it in console mode. With a public IP address, clients can now chat from anywhere and at any time, without needing to be on the same LAN.

## Install and Run the Project

To run this application, you will need:
- Server (virtual computer)
- Visual Studio (2019 or later)
- .NET Framework 6.0

## How to use
To use this project, please follow these steps:
- Clone/download this project to your devices
- Open the solution file (TCPChat.sln) in visual studio
- Build the solution
- Start running Server project if you are an administrator
- Start running Client project if you are an user
- After build and run the first time, if you want to use the application again, you can find .exe file in in debug folder.

### As a client
After running the Client project, you will need to ask the administrator the Server IP and the PORT. After that, just follow the instruction in the application and you can use it normally.

### As an administrator

After running the Server project, you will need to find out the Port number and fill it in the textbox, you can use any Port that can be use. Remember to announce the Port so that user can connect to the Server. Finally, click the listen button and the Server will start to listen user's connecting request.
## Features
- Multiple clients can connect to the server and communicate with each other
- Each client can send and receive messages in real-time
- Allow client to send text messages, pictures, videos and files up to 100MB
- Download pictures, videos and files which are sent by other clients
- Client can use speech-to-text to compose the text message
- Send simple emoji
- Create group to chat with multiple clients at the same time
- Sign up new account, log in and log out

## Credits
This is the final project that was done by Group 4 of NT106.O22 - Fundamental Network Programming, University of Information Technology (UIT). Here is the group's member:
- Vo Tran Phi - 22521081  
Github link: [votranphi](https://github.com/votranphi) 
- Le Duong Minh Phuc - 22521116  
Github link: [minhphuc2544](https://github.com/minhphuc2544)
- Pham Tan Tai - 22521283  
Github link: [taicyberr](https://github.com/taicyberr)
