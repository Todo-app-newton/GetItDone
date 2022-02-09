import React, { Component } from 'react';
import { Col, Container, Form } from 'reactstrap';
import { Link } from 'react-router-dom'
import './Start.css'

export class Start extends Component {
    static displayName = Start.name;

    constructor(props) {
        super(props);
        this.state = {
            email: '',
            password: '',
            isLoggedIn: false
        };
    }
   

    handleChange = (e) => {
        this.setState({ [e.target.name]: e.target.value });
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
                                onChange={this.handleChange}
                                value={this.state.email}
                                placeholder="Enter email" />
                        </div>
                        <div className="form-group">
                            <label>Password</label>
                            <input type="password"
                                className="form-control"
                                name="password"
                                onChange={this.handleChange}
                                value={this.state.password}
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
                            onClick={() => this.incrementLogIn}
                        >Submit</button>
                        <p className="forgot-password text-right">
                            Forgot <a href="#">password?</a>
                        </p>
                    </Form>
                </Col>
            </Container>
        );

        let handleSubmit = async (e) => {
            e.preventDefault();
            try {
                let res = await fetch('login', {
                    method: "POST",
                    body: LoginUserModel({
                        email: email,
                        password: password,
                    }),
                });
                let resJson = await res.json();
                if (res.status === 200) {
                    setMessage("User created successfully");
                } else {
                    setMessage("Some error occured");
                }
            } catch (err) {
                console.log(err);
            }
    }

}

