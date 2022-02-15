import React, { Component } from 'react';
import { Row, Col, Container, Form } from 'reactstrap';
import profilePic from './profilepic.png';
import './ProfilePage.css'

export class ProfilePage extends Component {
    static displayName = ProfilePage.name;

    constructor(props) {
        super(props);
        this.state = {
            Profile: {
                id: '',
                firstName: '',
                lastName: '',
                phone: '',
                email:'',
                profession: '',
                company: '',
                assignments:[],
            }

        };
    }
    static renderProfile(Profile) {
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
                                    <li><b>Phone: </b></li>
                                    <li><b>Email: </b></li>
                                </ul>
                            </Col>
                            <Col>
                                <ul>
                                    <li>{Profile.firstName} {Profile.lastName}</li>
                                    <li>{Profile.phone}</li>
                                    <li>{Profile.email}</li>
                                </ul>
                            </Col>
                        </Row>
                        <Row className="work-info">
                            <Col>
                                <ul>
                                    <li><b>Profession: </b></li>
                                    <li><b>Company: </b></li>
                                    <li><b>Asignments: </b></li>
                                </ul>
                            </Col>
                            <Col>
                                <ul>
                                    <li>{Profile.profession}</li>
                                    <li>{Profile.company}</li>
                                    <li>Show assignments</li>
                                </ul>
                            </Col>
                        </Row>
                    </Col>
                </Row>
            </Container>
        );
    }
    render() {
        let contents = this.state.loading
            ? <p><em>Loading...</em></p>
            : ProfilePage.renderProfile(this.state.Profile);

        return (
            <div>
                {contents}
            </div>
        );
    }
}