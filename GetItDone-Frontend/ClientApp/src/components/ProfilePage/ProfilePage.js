import React, { Component } from 'react';
import { Row, Col, Container, Form } from 'reactstrap';
import profilePic from './profilepic.png';
import './ProfilePage.css'

export class ProfilePage extends Component {
    static displayName = ProfilePage.name;

    constructor(props) {
        super(props);
        this.state = {
            profile: '',
            lastName: '',
            role: '',
            email: '',
            profession: '',
            company: '',

        };
    }

    componentDidMount() {
        this.fetchLoggedInRole();
    }
    render() {
        let userProfile = this.state.profile
        return (
            <Container fluid="md">
                <Row className="justify-content-md-center">
                    <Col lg={8} sm={12} className="profile">
                        <h1 id="tabelLabel" >Profile page</h1>
                        <Row className="profile-img-holder">
                            <img fluid
                                className="img-profile"
                                src={profilePic}
                                alt="profile"
                            />
                        </Row>
                        <Row className="profile-info">
                            <Col>
                                <ul>
                                    <li><b>Name: </b></li>
                                    <li><b>Email: </b></li>
                                    <li><b>Role: </b></li>
                                </ul>
                            </Col>
                            <Col>
                                <ul>
                                    <li>{userProfile.firstName} {userProfile.lastName}</li>
                                    <li>{userProfile.email}</li>
                                    <li>{userProfile.role}</li>
                                </ul>
                            </Col>
                        </Row>
                        {userProfile.role === "Employee" ?
                        <Row className="work-info">
                            <Col>
                                <ul>
                                    <li><b>Profession: </b></li>
                                    <li><b>Company: </b></li>
                                </ul>
                            </Col>
                            <Col>
                                <ul>
                                    <li>{userProfile.profession}</li>
                                    <li>{userProfile.company}</li>
                                </ul>
                            </Col>
                        </Row> : null}
                    </Col>
                </Row>
            </Container>
        );
    }
    async fetchLoggedInRole() {
            const response = await fetch('api/ProjectManager/ProjectManagersProfile');
            const manager = await response.json();
            this.setState({
                profile:manager,
                loading: false
            });
    }
}