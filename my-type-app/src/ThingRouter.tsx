import React from "react";
import Navbar from 'react-bootstrap/Navbar';
import Nav from 'react-bootstrap/Nav';
import {
    BrowserRouter as Router,
    Switch,
    Route,
    Link
  } from "react-router-dom";
import Home from './Home';
import Auctions from './Auctions';
import Things from './Things';
import ThingCreate from './ThingCreate';

  export default function BasicExample() {
    return (
      <Router>
        <div>
        <Navbar bg="light" expand="lg">
           <Nav>
                  
                  <Nav.Link href="#link">
                      <Link to="/things">List</Link>  
                  </Nav.Link>
                  <Nav.Link href="#link">
                      <Link to="/create">Create new</Link>  
                  </Nav.Link> 
                  
            </Nav>   
        </Navbar>
          <Switch>
            <Route path="/things">
              <Things />
            </Route>
            <Route path="/create">
              <ThingCreate />
            </Route>
          </Switch>
        </div>
      </Router>
    );
  }

  