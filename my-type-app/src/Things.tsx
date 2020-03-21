import React from "react";
import { useState } from 'react';
import { useEffect } from 'react';
import axios from 'axios';



let deflist : any[] =[
    {id: "", name: "hello ", descpription: " ", personid: ""},
];


function ThingList(){
    const [data, setData] = useState(deflist);
    const [url, setUrl] = useState('https://localhost:5001/api/thing',);
    const [isLoading, setIsLoading] = useState(false);
    const [isError, setIsError] = useState(false);

    useEffect(() => {
      const fetchData = async () => {
        setIsError(false);
        setIsLoading(true);
        try {
          const res = await axios(url);
          setData(res.data);
        } catch (error) {
          setIsError(true);
          console.log(error);
        }
        setIsLoading(false);
      };
      fetchData();
    }, [url]);

  return (
    <div>
      {isError && <div>Something went wrong ...</div>}
      {isLoading ? (
        <div>Loading ...</div>
      ) : (
        <ul>
          {
          data.map(item => (
            <li>
              <a>{item.name}</a>
            </li>
          ))}
        </ul>
      )}
    </div>
  );
}

export default function Things(){
    return(
        <div>  
            <ThingList/>
        </div>
    )
}


