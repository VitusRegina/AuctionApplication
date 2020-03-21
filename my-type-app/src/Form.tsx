import React, { useEffect,useState } from "react";
import Form from 'react-bootstrap/Form'
import Button from 'react-bootstrap/Button'


function MyForm(){
  const [count, setCount] = useState(0);
  useEffect(() => {
    document.title = `You clicked ${count} times`;
   });
   
  return(
    <Form>
      <Form.Group controlId="formBasicEmail">
      <Form.Label>Email address</Form.Label>
      <Form.Control type="email" placeholder="Enter email" />
      </Form.Group>

      <Form.Group controlId="formBasicPassword">
      <Form.Label>Password</Form.Label>
      <Form.Control type="password" placeholder="Password" />
      </Form.Group>
  
       <Button variant="primary" type="submit">
        Submit
      </Button>

      <Button onClick={() => setCount(count + 1)}>
        Click me
      </Button>
</Form>
  )
}

export default function Dashboard() {
    return (
      <div>
        <h2>Form will be here</h2>
        <MyForm />
      </div>
    );
  }