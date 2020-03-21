import React, { useState,useEffect } from 'react';
import { HubConnection } from '@aspnet/signalr';

export default function Chat(){
    const [nick, setNick] = useState(' ');
    const [message, setMessage] = useState(' ');
    const [messages, setMessages] = useState([]);
    const [hubConnection, setConnection] = useState();

   /* const sendMessage = () => {
        hubConnection
          .invoke('sendMessage', nick, message)
          .catch(err => console.error(err));
      
          setMessage('');      
      };*/

    useEffect(()=>{
       
    }
    )

    return(
         <div>Here goes chat</div>
    )
}