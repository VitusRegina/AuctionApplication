import React from "react";
import { useState } from 'react';
import { useEffect } from 'react';
import axios from 'axios';
import Container from 'react-bootstrap/Container';
import Row from 'react-bootstrap/Row';
import Col from 'react-bootstrap/Col';
import Card from 'react-bootstrap/Card';
import Button from "react-bootstrap/Button";

let deflist : any[] =[
    {id: "", name: "hello ", descpription: " ", personid: ""},
];


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
               <Card.Body>{item.thingDescription}</Card.Body>
               <Card.Footer >
                Actual price: {item.actualPrice                       }
                <Button variant="primary">Bid</Button>
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

