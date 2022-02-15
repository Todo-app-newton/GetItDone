import React, { Component } from 'react';
import './Assignments.css'
import headerImg from '../Assignments.png';

export class Assignment extends Component {
    static displayName = Assignment.name;

    constructor(props) {
        super(props);
        this.complete = this.complete.bind(this);
        this.start = this.start.bind(this);
        this.edit = this.edit.bind(this);
        this.state = {
            pendingAssignmentsviewmodel: [],
            loading: true,
            startedAssignmentssviewmodel: [],
            completedAssignmentssviewmodel: []
        };
    }

    componentDidMount() {
        this.fetchPendingAssignments();
        this.fetchStartedAssignments();
        this.fetchCompletedAssignments();
    }


    complete = (event) => {
        let employeeIdViewModel = {
            Id: event.target.dataset.user
        };
        fetch('api/assignment/Complete', {
            method: 'POST',
            headers: { 'Content-type': 'application/json' },
            body: JSON.stringify(employeeIdViewModel),
        }).then(this.componentDidMount())
    }
    start = (event) => {
        let employeeIdViewModel = {
            Id: event.target.dataset.user
        };
        fetch('api/assignment/Start', {
            method: 'POST',
            headers: { 'Content-type': 'application/json' },
            body: JSON.stringify(employeeIdViewModel),
        }).then(this.componentDidMount())
    }
    edit = (event) => {
        let employeeIdViewModel = {
            Id: event.target.dataset.user
        };
        fetch('api/assignment/Edit', {
            method: 'PUT',
            headers: { 'Content-type': 'application/json' },
            body: JSON.stringify(employeeIdViewModel),
        }).then(this.componentDidMount())
    }

    static renderPendingAssignments(pendingAssignmentsviewmodel, complete, start, edit) {
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
                                onClick={edit}
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
 
    static renderStartedAssignments(startedAssignmentssviewmodel, complete, edit) {
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
                                onClick={edit}
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
            Assignment.renderPendingAssignments(this.state.pendingAssignmentsviewmodel, this.complete, this.start, this.edit);
        let startedcontents = this.state.loading ?
            <p><em>Loading...</em></p> :
            Assignment.renderStartedAssignments(this.state.startedAssignmentssviewmodel, this.complete, this.edit);

        let completedcontents = this.state.loading ?
            <p><em>Loading...</em></p> :
            Assignment.renderCompletedAssignments(this.state.completedAssignmentssviewmodel); 

        return (
            <div>

                <container>
                    <div className="img-header">
                    <img src={headerImg} alt="headerImg" className="assignmentImage" />
                    </div>
                 </container>



                <h1 id="PendingLabel1" >Pending Assignments</h1>
                <p>These are pending assignments </p>
                {pendingcontents}
           
                <h1 id="StartedLabel2" >Started Assignments</h1>
                <p>These are started assignments </p>
                {startedcontents}

                <h1 id="tabelLabel3" >Completed Assignments</h1>
                <p>These are Completed assignments </p>
                {completedcontents}
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