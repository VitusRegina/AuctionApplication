import React from "react";
import 'bootstrap/dist/css/bootstrap.min.css';
import Home from './Home';
import List from './List';
import Things from './Things';
import Chat from './Chat';
import Navbar from 'react-bootstrap/Navbar';
import Nav from 'react-bootstrap/Nav';
import {
  BrowserRouter as Router,
  Switch,
  Route,
  Link
} from "react-router-dom";


export default function BasicExample() {
  return (
    <Router>
      <div>
      <Navbar bg="dark" expand="lg">
         <Nav className="mr-auto">
                <Nav.Link href="#home">
                    <Link to="/">Home</Link>
                </Nav.Link>
                <Nav.Link href="#link">
                    <Link to="/list">List</Link>  
                </Nav.Link> 
                <Nav.Link href="#link">
                    <Link to="/things">Things</Link>  
                </Nav.Link>
                
          </Nav>   
      </Navbar>

        <Switch>
          <Route exact path="/">
            <Home />
          </Route>
          <Route path="/list">
            <List />
          </Route>
          <Route path="/things">
            <Things />
          </Route>
          <Route path="/chat">
            <Chat />
          </Route>
        </Switch>
      </div>
    </Router>
  );
}




