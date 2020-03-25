import React from "react";
import { useState } from 'react';
import { useEffect } from 'react';
import axios from 'axios';
import Container from 'react-bootstrap/Container';
import Row from 'react-bootstrap/Row';
import Accordion from 'react-bootstrap/Accordion';
import Col from 'react-bootstrap/Col';
import Card from 'react-bootstrap/Card';
import Button from "react-bootstrap/Button";

interface IProp{
  id : number;
  sum : number;
}

let deflist : any[] =[
    {id: "", name: "hello ", descpription: " ", personid: ""},
];


function Bid(props:IProp){
const [sum, setSum] = useState(0);
const [id, setId] = useState(props.id);


function handleChange(e: React.FormEvent<HTMLInputElement>) {
  setSum(+e.currentTarget.value);
  console.log(sum);
}

const handleSubmit= async ()=> {
 if(sum>props.sum){
  await axios.post('https://localhost:5001/api/bid', {
      "sum": sum,
      "auctionid": id
    })
    console.log("Bid created");
    window.location.reload();
  }
}
  return (
    <div>
        <form>
            <div>
            <label>
             Sum:
             <input type="number" value={sum} onChange={handleChange} />
             </label>
            <Button onClick={handleSubmit}>Send</Button>
        </div>
    </form>
    </div>
  );
}

function Biding(props:IProp){
  const [data, setData] = useState(deflist);
  const i:number =props.id;
  const [url, setUrl] = useState('https://localhost:5001/api/bid'+i,);
  const [isLoading, setIsLoading] = useState(false);
  const [isError, setIsError] = useState(false);

  useEffect(() => {
    const fetchData = async () => {
      setIsError(false);
      setIsLoading(true);
      try {
        const res = await axios.get('https://localhost:5001/api/bid/'+i,);
        setData(res.data);
      } catch (error) {
        setIsError(true);
        console.log(error);
      }
      setIsLoading(false);
    };
    fetchData();
  }, [url]);

  return(
    <div>
      {isError && <div>Something went wrong ...{i}</div>}
      {isLoading ? (
        <div>Loading ...</div>
      ) : (
       <div>
          <ul>
          {
          data.map(item => (
          <li>{item.sum}</li>
          ))}
          </ul>
        <hr />
        Actual price: {props.sum}
        <hr /> 
        <Bid id={props.id} sum={props.sum}/>
        </div>
      )}
    </div>
  )
}


function Accord(props:IProp){
  return(
    <Accordion>
        <Card>
              <Card.Header>
                    <Accordion.Toggle as={Button} variant="link" eventKey="0">
                    Bid
                     </Accordion.Toggle>
              </Card.Header>
              <Accordion.Collapse eventKey="0">
              <Card.Body>
              <Biding id={props.id} sum={props.sum}/>
              </Card.Body>
              </Accordion.Collapse>
        </Card>
    </Accordion>
  )
}


function AuctionList(){
    const [data, setData] = useState(deflist);
    const [url, setUrl] = useState('https://localhost:5001/api/auction',);
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
               <Card bg='light'>
          <Card.Title>{item.thingName}</Card.Title>
               <Card.Body>{item.thingDescription} <hr />Actual price: {item.actualPrice}</Card.Body>
               <Card.Footer >
               <Accord id={item.id} sum={item.actualPrice}/>
               </Card.Footer>
               </Card>
              </Col>
            </Row>
          ))}
        </Container>
      )}
    </div>
  );
  
}

export default function Auctions(){
    return(
        <div>
            <AuctionList />
        </div>
    )
}

