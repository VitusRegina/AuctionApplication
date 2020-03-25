import React from "react";
import { useState } from 'react';
import { useEffect } from 'react';
import axios from 'axios';
import Button from "react-bootstrap/Button";

const s:string='';

function Form() {
    const [name, setName] = useState(s);
    const [description, setDescription] = useState(s);
  
    function handleChange1(e: React.FormEvent<HTMLInputElement>) {
      setName(e.currentTarget.value);
      console.log(name);
    }

    function handleChange2(e: React.FormEvent<HTMLInputElement>) {
        setDescription(e.currentTarget.value);
        console.log(description)
      }
  
    const handleSubmit= async ()=> {
        await axios.post('https://localhost:5001/api/thing', {
            "name": name,
            "desccription": description
          })
          console.log("Thing created");
         
    }
  
    
      return (
        <div>
            <form>
                <div>
                <label>
                 Name:
                 <input type="text" value={name} onChange={handleChange1} />
                 </label>
            </div>
            <div>
             <label>
               Description:
                 <input type="text" value={description} onChange={handleChange2} />
                </label>
                <div><Button onClick={handleSubmit}>Submit</Button></div>
               
             </div>
        </form>
        </div>
      );
    
  }


export default function Create(){
    return(
        <div>
            <Form />
        </div>
    )
}