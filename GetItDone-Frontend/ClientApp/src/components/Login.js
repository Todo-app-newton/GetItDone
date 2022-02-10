import React, { Component } from 'react';
import { Col, Container, Form } from 'reactstrap';
import { Link } from 'react-router-dom'
import './Login/Login.css'

export class Login extends Component {
    static displayName = Login.name;

    constructor(props) {
        super(props);
        this.state = {
            clickButton: false,
            isLoggedIn: false,
            loginUser:{
                email: '',
                password: '',}

        };
        this.handleChange = this.handleChange.bind(this);
        this.handleSubmit = this.handleSubmit.bind(this);
    }
   
    handleChange(e) {
        this.setState({ [e.target.name]: e.target.value });
    }

    handleSubmit() {
        console.log('handleSubmit')
        this.sendLogin();
    }

    render() {

        return (
            <Container>
                <Col lg={6} sm={12} className="m-auto">
                    <Form>
                        <h3>Sign In</h3>
                        <div className="form-group">
                            <label>Email address</label>
                            <input type="email"
                                className="form-control"
                                name="email"
                                value={this.state.email}
                                onChange={this.handleChange}
                                placeholder="Enter email" />
                        </div>
                        <div className="form-group">
                            <label>Password</label>
                            <input type="password"
                                className="form-control"
                                name="password"
                                value={this.state.password}
                                onChange={this.handleChange}
                                placeholder="Enter password" />
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
                            onClick={this.handleSubmit}
                        >Submit</button>
                        <p className="forgot-password text-right">
                            Forgot <a href="#">password?</a>
                        </p>
                    </Form>
                </Col>
            </Container>
        );
    }
    async sendLogin() {
        const response = await fetch('login', { method: 'POST', body: this.state.email });
        const data = await response.json();
        this.setState({ forecasts: data});
        console.log(data);
        //if (data === true) { this.setState({ isLoggedIn: data }); }
    }
}

