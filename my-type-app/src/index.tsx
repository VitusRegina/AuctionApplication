import React from "react";
import ReactDOM from "react-dom";
import 'bootstrap/dist/css/bootstrap.min.css';
import Home from './Home';
import Auctions from './Auctions';
import Chat from './Chat';
import ThingRouter from './ThingRouter'
import Navbar from 'react-bootstrap/Navbar';
import Nav from 'react-bootstrap/Nav';
import {
  BrowserRouter as Router,
  Switch,
  Route,
  Link
} from "react-router-dom";


 function BasicExample() {
  return (
    <Router>
      <div>
      <Navbar bg="dark" expand="lg">
         <Nav>
                <Nav.Link href="#home">
                    <Link to="/">Home</Link>
                </Nav.Link>
                <Nav.Link href="#link">
                    <Link to="/auctions">Auctions</Link>  
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
          <Route path="/auctions">
            <Auctions />
          </Route>
          <Route path="/things">
            <ThingRouter />
          </Route>
          <Route path="/chat">
            <Chat />
          </Route>
        </Switch>
      </div>
    </Router>
  );
}


ReactDOM.render(
    <BasicExample />,
    document.getElementById('root')
    );
    


