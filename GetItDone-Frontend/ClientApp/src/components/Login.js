import React, { Component } from 'react';
import { Row, Col, Container, Form } from 'reactstrap';
import logo from './logo.jpg';
import background from './background-login2.jpg';
import './Login/Login.css'
import { Redirect } from 'react-router-dom'

export class Login extends Component {
    static displayName = Login.name;

    constructor(props) {
        super(props);
        this.state = {
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

    handleSubmit(e) {
        let loginUserModel = {
            Email: this.state.email,
            Password:this.state.password
        };
        e.preventDefault();
        fetch('login', {
            method: 'POST',
            headers: { 'Content-type': 'application/json' },
            credentials: 'include',
            body: JSON.stringify(loginUserModel)
        }).then(r => r.json()).then(res => {
            if (res.email) {
                this.state.isLoggedIn = true;
                this.props.history.push({
                    pathname: '/Home',
                    state: { email: res.email }
                })
            }
            else {
                <Redirect to='/Login' />
            }
        });
    }

    render() {

        return (
            <Container fluid>
                <Row>
                    <Col lg={6} sm={12} className="m-auto">
                        <div className="img-holder">
                            <img fluid
                                className="img-fluid"
                                src={logo}
                                alt="logo"
                            />
                        </div>
                    </Col>
                    <Col lg={6} sm={12} className="m-auto" style={{ backgroundImage: `url(${background})` }}>
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
                </Row>
            </Container>

        );
    }

    /*async sendLogin(e) {
        const response = await fetch('login', { method: 'POST', body: e });
        const data = await response.json();
        console.log(data);
        this.sleep(50000)
        //if (data === true) { this.setState({ isLoggedIn: data }); }
    }*/
}

