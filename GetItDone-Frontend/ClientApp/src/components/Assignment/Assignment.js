import React, { Component } from 'react';
import './Assignments.css'
import headerImg from '../Assignments.png';
import { Modal, ModalBody, ModalHeader, ModalFooter, Button } from 'reactstrap';


export class Assignment extends Component {
    static displayName = Assignment.name;

    constructor(props) {
        super(props);
        this.complete = this.complete.bind(this);
        this.start = this.start.bind(this);
        this.edit = this.edit.bind(this);
        this.toggleModal = this.toggleModal.bind(this);
        this.handleChange = this.handleChange.bind(this);
        this.state = {
            pendingAssignmentsviewmodel: [],
            loading: true,
            startedAssignmentssviewmodel: [],
            completedAssignmentssviewmodel: [],
            showHide: false,
            title: '',
            description: '',
            progress: '',
            period: new Date(),
            id: '',
        };
    }

    componentDidMount() {
        this.fetchPendingAssignments();
        this.fetchStartedAssignments();
        this.fetchCompletedAssignments();
    }

    handleChange(e) {
        this.setState({ [e.target.name]: e.target.value });
    }


    complete = (event) => {
        let employeeIdViewModel = {
            Id: event.target.dataset.user
        };
        fetch('api/assignment/Complete', {
            method: 'POST',
            headers: { 'Content-type': 'application/json' },
            body: JSON.stringify(employeeIdViewModel),
        }).then(window.location.reload(false))
    }
    start = (event) => {
        let employeeIdViewModel = {
            Id: event.target.dataset.user
        };
        fetch('api/assignment/Start', {
            method: 'POST',
            headers: { 'Content-type': 'application/json' },
            body: JSON.stringify(employeeIdViewModel),
        }).then(window.location.reload(false))
    }
    toggleModal = (event) => {
        this.setState({ showHide: !this.state.showHide, id: event.target.dataset.user })
    }
    edit = (e) => {
        let assignmentViewModelEdit = {
            Id: this.state.id,
            Title: this.state.title,
            Description: this.state.description,
            Period: this.state.period,
            Progress: this.state.progress    
        };
        e.preventDefault();
        fetch('api/assignment/UpdateAssignment', {
            method: 'PUT',
            headers: { 'Content-type': 'application/json' },
            body: JSON.stringify(assignmentViewModelEdit),
        }).then(window.location.reload(false))
    }


    static renderPendingAssignments(pendingAssignmentsviewmodel, complete, start, toggleModal) {
        return (
              <table className='table table-striped' aria-labelledby="tabelLabel1">
                <thead>
                    <tr>
                        <th>Id</th>
                        <th>Title</th>
                        <th>Description</th>
                        <th>Period</th>
                        <th>Progress</th>
                        <th>ProjectId</th>
                        <th>EmployeeId</th>
                    </tr>
                </thead>
                <tbody>
                    {pendingAssignmentsviewmodel.map(assignment =>
                        <tr key={assignment.id}>
                            <td>{assignment.id}</td>
                            <td>{assignment.title}</td>
                            <td>{assignment.description}</td>
                            <td>{assignment.period}</td>
                            <td>{assignment.progress}</td>
                            <td>{assignment.projectId}</td>
                            <td>{assignment.employeeId}</td>
                            <td
                                className="btn btn-primary"
                                data-user={assignment.id}
                                onClick={toggleModal}
                            >Edit</td>
                            {assignment.progress != 'Start' ?
                                <td
                                    className="btn btn-info"
                                    data-user={assignment.id}
                                    onClick={start}
                                >Start</td> : ''}
                            {assignment.progress != 'Complete' ?
                                <td
                                    className="btn btn-success"
                                    data-user={assignment.id}
                                    onClick={complete}
                                >Complete</td> : ''}
                           
                               
                        </tr>
                    )}
                </tbody>
            </table>
        );
    }
 
    static renderStartedAssignments(startedAssignmentssviewmodel, complete, toggleModal) {
        return (
            <table className='table table-striped' aria-labelledby="StartedLabel2">
                <thead>
                    <tr>
                        <th>Id</th>
                        <th>Title</th>
                        <th>Description</th>
                        <th>Period</th>
                        <th>Progress</th>
                        <th>ProjectId</th>
                        <th>EmployeeId</th>
                    </tr>
                </thead>
                <tbody>
                    {startedAssignmentssviewmodel.map(assignment =>
                        <tr key={assignment.id}>
                            <td>{assignment.id}</td>
                            <td>{assignment.title}</td>
                            <td>{assignment.description}</td>
                            <td>{assignment.period}</td>
                            <td>{assignment.progress}</td>
                            <td>{assignment.projectId}</td>
                            <td>{assignment.employeeId}</td>
                            <td
                                className="btn btn-info"
                                data-user={assignment.id}
                                onClick={toggleModal}
                            >Edit</td>
                            {assignment.progress != 'Complete' ?
                                <td
                                    className="btn btn-success"
                                    data-user={assignment.id}
                                    onClick={complete}
                                >Complete</td> : ''}   
                          
                        </tr>
                    )}
                </tbody>
            </table>
        );
    }

    static renderCompletedAssignments(completedAssignmentssviewmodel) {
        return (
            <table className='table table-striped' aria-labelledby="tabelLabel3">
                <thead>
                    <tr>
                        <th>Id</th>
                        <th>Title</th>
                        <th>Description</th>
                        <th>Period</th>
                        <th>Progress</th>
                        <th>ProjectId</th>
                        <th>EmployeeId</th>
                    </tr>
                </thead>
                <tbody>
                    {completedAssignmentssviewmodel.map(assignment =>
                        <tr key={assignment.id}>
                            <td>{assignment.id}</td>
                            <td>{assignment.title}</td>
                            <td>{assignment.description}</td>
                            <td>{assignment.period}</td>
                            <td>{assignment.progress}</td>
                            <td>{assignment.projectId}</td>
                            <td>{assignment.employeeId}</td>
                        </tr>
                    )}
                </tbody>
            </table>
        );
    }




    

    render() {
        let pendingcontents = this.state.loading ?
            <p><em>Loading...</em></p> :
            Assignment.renderPendingAssignments(this.state.pendingAssignmentsviewmodel, this.complete, this.start, this.toggleModal);
        let startedcontents = this.state.loading ?
            <p><em>Loading...</em></p> :
            Assignment.renderStartedAssignments(this.state.startedAssignmentssviewmodel, this.complete, this.toggleModal);

        let completedcontents = this.state.loading ?
            <p><em>Loading...</em></p> :
            Assignment.renderCompletedAssignments(this.state.completedAssignmentssviewmodel); 

        let toggle = this.toggleModal;

        return (
            <div>

                <container>
                    <div className="img-header">
                    <img src={headerImg} alt="headerImg" className="assignmentImage" />
                    </div>
                 </container>

                <h1 id="PendingLabel1" >Pending Assignments</h1>
                {pendingcontents}
           
                <h1 id="StartedLabel2" >Started Assignments</h1>
                {startedcontents}

                <h1 id="tabelLabel3" >Completed Assignments</h1>
                {completedcontents}

                <Modal isOpen={this.state.showHide} className="Modal">
                    <ModalHeader> Edit Assignment</ModalHeader>
                    <ModalBody>
                        <form class="Assignment-form">
                                <div class="inputs">
                                    <label>Title</label>
                                    <br />
                                    <input type="text" name="title" value={this.state.title} onChange={this.handleChange} placeholder="Titel" />
                                </div>
                                <div class="inputs">
                                    <label> Description</label>
                                    <br />
                                    <input type="text" name="description" value={this.state.description} onChange={this.handleChange} placeholder="Description" />
                                </div>
                                <div class="inputs">
                                    <label>Period</label>
                                    <br/>
                                    <input type="date" name="period" value={this.state.period} onChange={this.handleChange} placeholder="Period" />
                                </div>
                                <div class="inputs">
                                    <label>Progress (0 = Pending, 1 = Started, 2 = Paused, 3 = Completed)</label>
                                    <br />
                                    <input type="text" min="0" max="3" name="progress" value={this.state.progress} onChange={this.handleChange} placeholder="Progress" />
                            </div>
                                <div class="sumbitBtn">
                                <button type="submit" className="btn btn-primary btn-block assBtn" onClick={this.edit}>Confirm </button>
                                </div>
                             </form> 
                    </ModalBody>
                    <ModalFooter>                      
                                        {' '}
                        <Button onClick={toggle}>Cancel</Button>
                    </ModalFooter>
                </Modal>

            </div>
            );
     }


    async fetchStartedAssignments() {
        const response = await fetch('api/Assignment/FetchStarted');
        const data = await response.json();
        this.setState({ startedAssignmentssviewmodel: data, loading: false });
    }

    async fetchPendingAssignments() {
        const response = await fetch('api/Assignment/FetchPending');
        const data = await response.json();
        this.setState({ pendingAssignmentsviewmodel: data, loading: false });
    }
    async fetchCompletedAssignments() {
        const response = await fetch('api/Assignment/FetchCompleted');
        const data = await response.json();
        this.setState({ completedAssignmentssviewmodel: data, loading: false });
    }
} 