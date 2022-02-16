import React, { Component } from 'react';
import './ProjectManager.css'
import {
    Card, CardImg, CardText, CardBody,
    CardTitle
} from 'reactstrap';
import assignmentImg from "./assignment.png";
import companyImg from './company.jpg';
import createEmployeeImg from './CreateEmployee.jpg';
import CustomerImg from './Customer.jpg';
import { Modal, ModalBody, ModalHeader, ModalFooter, Button } from 'reactstrap';
import projectImg from './Project.jpg';



export class ProjectManager extends Component {
    static displayName = ProjectManager.name;

    constructor(props) {
        super(props);
        this.createemployee = this.createemployee.bind(this);

        this.toggleCreateEmpModal = this.toggleCreateEmpModal.bind(this);
        this.toggleCreateCustomerModal = this.toggleCreateCustomerModal.bind(this);
        this.toggleCreateAssignmentModal = this.toggleCreateAssignmentModal.bind(this);
        this.toggleCreateCompany = this.toggleCreateCompany.bind(this);
        this.handleChange = this.handleChange.bind(this);   



        this.state = {
            ProjectManagerViewModel: '',
            showCreateEmp: false,
            showCreateCustomer: false,
            showCreateAssignModal: false,
            showCreateCompany: false,
            firstname: '',
            lastname: '',
            email: '',
            profession: '',
            companyid: '',
            password: '',
            
        };
    }

    componentDidMount() {
        this.getProjectManagersName();
    }

    handleChange(e) {
        this.setState({ [e.target.name]: e.target.value });
    }


    toggleCreateEmpModal = (event) => {
        this.setState({ showCreateEmp: !this.state.showCreateEmp })
    }
    toggleCreateCustomerModal = (event) => {
        this.setState({ showCreateCustomer: !this.state.showCreateCustomer })
    }
    toggleCreateAssignmentModal = (event) => {
        this.setState({ showCreateAssignModal: !this.state.showCreateAssignModal })
    }
    toggleCreateCompany = (event) => {
        this.setState({ showCreateCompany: !this.state.showCreateCompany })
    }




    CreateAssignment = (event) => {
        let employeeDto = {
            FirstName: this.state.firstName,
            LastName: this.state.lastName,
            Email: this.state.email,
            Profession: this.state.profession,
            CompanyId: this.state.companyId
        };

        fetch('api/assignment/CreateEmployee', {
            method: 'POST',
            headers: { 'Content-type': 'application/json' },
            body: JSON.stringify(employeeDto),
        }).then(window.location.reload(false))
    }
    CreateCustomer = (event) => {
        let employeeDto = {
            FirstName: this.state.firstName,
            LastName: this.state.lastName,
            Email: this.state.email,
            Profession: this.state.profession,
            CompanyId: this.state.companyId
        };

        fetch('api/assignment/CreateEmployee', {
            method: 'POST',
            headers: { 'Content-type': 'application/json' },
            body: JSON.stringify(employeeDto),
        }).then(window.location.reload(false))
    }
    CreateCompany = (event) => {
        let employeeDto = {
            FirstName: this.state.firstName,
            LastName: this.state.lastName,
            Email: this.state.email,
            Profession: this.state.profession,
            CompanyId: this.state.companyId
        };

        fetch('api/assignment/CreateEmployee', {
            method: 'POST',
            headers: { 'Content-type': 'application/json' },
            body: JSON.stringify(employeeDto),
        }).then(window.location.reload(false))
    }
    createemployee = (e) => {
        let employeeDTO = {
            FirstName: this.state.firstname,
            LastName: this.state.lastname,
            Email: this.state.email,
            Profession: this.state.profession,
            CompanyId: this.state.companyid,
            Password: this.state.password
        };
        e.preventDefault();
        fetch('api/projectmanager/CreateEmployee', {
            method: 'POST',
            headers: { 'Content-type': 'application/json' },
            body: JSON.stringify(employeeDTO),
        }).then(window.location.reload(false))
    }
    
    render() {

        let projectMan = this.state.ProjectManagerViewModel;
       //let toggleCreateEmp = this.toggleCreateEmployee;

        return (
            <div>
                <container>
                    <div className="HeaderText">
                    <h1 className="Title">WELCOME TO THE PROJECTMANAGER PAGE</h1>
                        <p className="ProjectManagerName">What do you want to do today {projectMan.firstName} {projectMan.lastName} ? </p>
                    </div>
                </container>

                <div className="cards">

                    <Card className="card" style={{ width: '18rem' }}>
                        <CardImg variant="top" className="card-image" src={projectImg} />
                        <CardBody>
                            <CardTitle className="cardtitle">Create Project</CardTitle>
                            <CardText>
                                Use this one if you needs to create a new project.
                         </CardText>
                            <div className="buttonCard">
                                <Button variant="primary" className="btn btn-primary">Create Project</Button>
                            </div>
                        </CardBody>
                    </Card>


                    <Card className="card" style={{ width: '18rem' }}>
                        <CardImg variant="top" className="card-image"  src={assignmentImg} />
                    <CardBody>
                            <CardTitle className="cardtitle">Assign Assignment</CardTitle>
                        <CardText>
                                Use this one if you want to create a new assignment.
                         </CardText>
                            <div className="buttonCard">
                                <Button variant="primary" className="btn btn-primary">Create Assignment</Button>
                            </div>
                    </CardBody>
                </Card>


                    <Card className="card"  style={{ width: '18rem' }}>
                        <CardImg variant="top" className="card-image"  src={createEmployeeImg} />
                    <CardBody>
                            <CardTitle className="cardtitle">Create Employee</CardTitle>
                        <CardText>
                                Use this one if you want to create a new Employee.
   
                         </CardText>
                            <div className="buttonCard">
                                <Button variant="primary" className="btn btn-primary" onClick={this.toggleCreateEmpModal}>Create Employee</Button>
                            </div>
                    </CardBody>
                </Card>

                    <Card className="card" style={{ width: '18rem' }}>
                        <CardImg variant="top" className="card-image"  src={CustomerImg} />
                    <CardBody>
                            <CardTitle className="cardtitle">Create Customer</CardTitle>
                        <CardText>
                                Use this one if you want to create a Customer.                      
                        </CardText>
                            <div className="buttonCard">
                                <Button variant="primary" className="btn btn-primary">Create Customer</Button>
                            </div>
                    </CardBody>
                </Card>

                    <Card className="card"  style={{ width: '18rem' }}>
                        <CardImg variant="top" className="card-image" src={companyImg} />
                    <CardBody >
                        <CardTitle className="cardtitle">Create Company</CardTitle>
                        <CardText>
                                Use this one to create a new Company.
                
                         </CardText>
                            <div className="buttonCard">
                                <Button variant="primary" className="btn btn-primary">Create Company</Button>
                            </div>
                    </CardBody>
                </Card>
                </div>          




                <Modal isOpen={this.state.showCreateEmp} className="Modal">
                    <ModalHeader>Create Employee</ModalHeader>
                    <ModalBody>
                        <form class="createEmp-form">
                            <div class="inputs">
                                <label>FirstName</label>
                                <br />
                                <input type="text" name="firstname" value={this.state.firstname} onChange={this.handleChange} placeholder="FirstName" />
                            </div>
                            <div class="inputs">
                                <label> LastName</label>
                                <br />
                                <input type="text" name="lastname" value={this.state.lastname} onChange={this.handleChange} placeholder="LastName" />
                            </div>
                            <div class="inputs">
                                <label>Email</label>
                                <br />
                                <input type="email" name="email" value={this.state.email} onChange={this.handleChange} placeholder="Email" />
                            </div>
                            <div class="inputs">
                                <label>Profession (0 = Painter, 1 = Carpenter, 2 = PlumberFitter, 3 = Electrician)</label>
                                <br />
                                <input type="text" min="0" max="3" name="profession" value={this.state.profession} onChange={this.handleChange} placeholder="Profession" />
                            </div>
                            <div class="inputs">
                                <label>Company Id</label>
                                <br />
                                <input type="text" name="companyid" value={this.state.companyid} onChange={this.handleChange} placeholder="Company ID" />
                            </div>
                            <div class="inputs">
                                <label>Employee Password</label>
                                <br />
                                <input type="text"  name="password" value={this.state.password} onChange={this.handleChange} placeholder="Employee password" />
                            </div>
                            <div class="sumbitBtn">
                                <button type="submit" className="btn btn-primary btn-block assBtn" onClick={this.createemployee}>Confirm </button>
                            </div>
                        </form>
                    </ModalBody>
                    <ModalFooter>
                        {' '}
                        <Button onClick={this.toggleCreateEmpModal}>Cancel</Button>
                    </ModalFooter>
                </Modal>







            </div>
        );
    }


    async getProjectManagersName() {
        const response = await fetch('api/ProjectManager/ProjectManagersName');
        const data = await response.json();
        this.setState({ ProjectManagerViewModel: data, loading: false });
    }
}
