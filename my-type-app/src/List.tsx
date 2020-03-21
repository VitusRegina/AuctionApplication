import React, { useState } from "react";
import 'bootstrap/dist/css/bootstrap.min.css';
import Container from 'react-bootstrap/Container';
import Row from 'react-bootstrap/Row';
import Col from 'react-bootstrap/Col';
import Card from 'react-bootstrap/Card';

interface IProp{
  title:string;
 
}

function Clicker(props: IProp){
  const [count, setCount] = useState(0);

  return(
  <div>
    <Card bg="light">
    
      <Card.Title>{props.title}</Card.Title>
      <Card.Body>
      <p>You clicked {count} times</p>
          <button onClick={() => setCount(count + 1)}>
          Click me
           </button>
    </Card.Body>
    </Card>  
    </div>
  )
}

export default function About() {
    return (
      <div>
        <Container>
  <Row>
    <Col> <Clicker title='1/3' /></Col>
    <Col> <Clicker title='2/3'/></Col>
    <Col> <Clicker title='3/3'/></Col>
  </Row>
  <Row>
    <Col> <Clicker title='1/3' /></Col>
    <Col> <Clicker title='2/3' /></Col>
    <Col> <Clicker title='3/3' /></Col>
  </Row>
</Container>
      </div>
    );
  }