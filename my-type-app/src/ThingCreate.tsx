import React from "react";
import { useState } from 'react';
import { useEffect } from 'react';
import axios from 'axios';

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
  
    const handleSubmit= ()=> {
       /* await axios.post('https://localhost:5001/api/thing', {
            "name": name,
            "desccription": description
          })*/
          console.log(name);
          console.log(description);
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
               <button onClick={handleSubmit}>Kuldes</button>
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