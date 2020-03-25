import React from "react";
import { useState } from 'react';
import { useEffect } from 'react';
import axios from 'axios';
import Container from 'react-bootstrap/Container';
import Row from 'react-bootstrap/Row';
import Col from 'react-bootstrap/Col';
import Card from 'react-bootstrap/Card';
import Button from "react-bootstrap/Button";
import Accordion from "react-bootstrap/Accordion";

interface IItem{
  id:number;
 name:string;
 description:string;
};

let deflist : any[] =[
    {id: "", name: "hello ", descpription: " ", personid: ""},
];

function AuctionCreate(props:IItem){
    const [sum, setSum] = useState('');
    const [id, setId] = useState(props.id);
  
    function handleChange(e: React.FormEvent<HTMLInputElement>) {
      setSum(e.currentTarget.value);
      console.log(sum);
    }
   
    const handleSubmit= async ()=> {
        await axios.post('https://localhost:5001/api/auction', {
            "sum": sum,
            "thingID": id
          });
          console.log("auction created");
    }
      return (
        <div>
            <form>
                <div>
                <label>
                 Startprice:
                 <input type="number" value={sum} onChange={handleChange} />
                 </label>
            </div>
            <div>
                <div><Button onClick={handleSubmit}>Create</Button></div>
            </div>
        </form>
        </div>
      );
}

function Delete(props:IItem){
  const i:number=props.id;
  const handleSubmit= async ()=> {
    
     await axios.delete('https://localhost:5001/api/thing/'+i, );
       console.log("deleted");
       
       window.location.reload();
      };
  return(
      <div>
        Do you really want to delete this item?
        <div><Button onClick={handleSubmit}>Delete</Button></div>
      </div>
  )
}

function Modify(props: IItem){
  const [name, setName] = useState(props.name);
    const [description, setDescription] = useState(props.description);
    const [id, setId] = useState(props.id);
    const i:number=id;
  
    function handleChange1(e: React.FormEvent<HTMLInputElement>) {
      setName(e.currentTarget.value);
      console.log(name);
    }
    function handleChange2(e: React.FormEvent<HTMLInputElement>) {
        setDescription(e.currentTarget.value);
        console.log(description)
      }
    const handleSubmit=async ()=> {
        
        await axios.put('https://localhost:5001/api/thing/'+i, {
            "id": id,
            "name": name,
            "desccription": description
          });
          
          window.location.reload();
          console.log("modified");
          
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
                <div><Button onClick={handleSubmit}>Save</Button></div>
               
             </div>
        </form>
        </div>
      );
}

function Accord(props:IItem){
  return(
    <Accordion>
        <Card>
              <Card.Header>
                    <Accordion.Toggle as={Button} variant="link" eventKey="0">
                    Modify
                     </Accordion.Toggle>
              </Card.Header>
              <Accordion.Collapse eventKey="0">
              <Card.Body><Modify id={props.id} name={props.name} description={props.description}/></Card.Body>
              </Accordion.Collapse>
        </Card>
        <Card>
              <Card.Header>
                    <Accordion.Toggle as={Button} variant="link" eventKey="1">
                    Delete
                     </Accordion.Toggle>
              </Card.Header>
              <Accordion.Collapse eventKey="1">
                     <Card.Body><Delete id={props.id} name={props.name} description={props.description}/></Card.Body>
              </Accordion.Collapse>
        </Card>
        <Card>
              <Card.Header>
                    <Accordion.Toggle as={Button} variant="link" eventKey="2">
                    Create Auction
                     </Accordion.Toggle>
              </Card.Header>
              <Accordion.Collapse eventKey="2">
                     <Card.Body><AuctionCreate id={props.id} name={props.name} description={props.description}/></Card.Body>
              </Accordion.Collapse>
        </Card>
    </Accordion>
  )
}


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
        <Container>
          {
          data.map(item => (
            <Row>
              <Col>
               <Card bg='light' className="text-center">
                   <Card.Title>{item.name}</Card.Title>
                     <Card.Body>{item.desccription}
                      <Accord id={item.id} name={item.name} description={item.desccription}/>
                    </Card.Body>
               </Card>
              </Col>
            </Row>
          ))}
        </Container>
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


