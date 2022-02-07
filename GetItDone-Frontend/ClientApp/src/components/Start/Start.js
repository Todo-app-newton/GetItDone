import React, { Component } from 'react';
import { Col, Container, Form } from 'reactstrap';
import { Link } from 'react-router-dom'
import './Start.css'

export class Start extends Component {
    static displayName = Start.name;

    constructor(props) {
        super(props);
        this.state = { isLoggedIn:false };
        this.incrementLogIn = this.incrementLogIn.bind(this);
    }

    incrementLogIn() {
        if (this.state.isLoggedIn = false) {
            this.setState({
                currentState: true
            });
        }
    }

  render() {
      return (
          <Container>
              <Col lg={6} sm={12} className="m-auto">
                <Form>
                    <h3>Sign In</h3>
                    <div className="form-group">
                        <label>Email address</label>
                        <input type="email" className="form-control" placeholder="Enter email" />
                    </div>
                    <div className="form-group">
                        <label>Password</label>
                        <input type="password" className="form-control" placeholder="Enter password" />
                    </div>
                    <div className="form-group">
                        <div className="custom-control custom-checkbox">
                            <input type="checkbox" className="custom-control-input" id="customCheck1" />
                            <label className="custom-control-label" htmlFor="customCheck1">Remember me</label>
                        </div>
                      </div>
                      <button
                          type="submit"
                          className="btn btn-primary btn-block"
                          onClick={this.incrementLogIn}
                          >Submit</button>
                    <p className="forgot-password text-right">
                        Forgot <a href="#">password?</a>
                    </p>
                </Form>
              </Col>
      </Container>
    );
  }
}
