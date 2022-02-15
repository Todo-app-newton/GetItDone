import React, { Component } from 'react';


export class Employee extends Component {
   static displayName = Employee.name;

    constructor(props) {
        super(props);
        this.handleClick = this.handleClick.bind(this);
        this.state = {
            assignmentviewmodels: [],
            loading: true,
            id: Number
        };
    }

    componentDidMount() {
        this.fetchEmployeeAssignments();
    }


   handleClick = idNumber => () => {
        console.log(idNumber)
        fetch('employee', {
            method: 'POST',
            header: { 'Content-type': 'application/json'},
            body: JSON.stringify(idNumber)
        }).then(r => r.json()).then(res => {
            if (res) {
                console.log(res)
            }
            this.sleep(5000)
        });
    }

    static renderEmployeeTable(assignmentviewmodels) {
        return (
            <table className='table table-striped' aria-labelledby="tabelLabelEmployee">
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
                    {assignmentviewmodels.map(assignment =>
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
                                onClick={this.handleClick(assignment.id)}
                            >Complete</td>
                            
                        </tr>
                    )}
                </tbody>

            </table>
        );
    }

    render() {
        let contents = this.state.loading ?
            <p><em>Loading...</em></p> :
            Employee.renderEmployeeTable(this.state.assignmentviewmodels);

        return (
            <div>
                <h1 id="tabelLabel" >Employee Assignments</h1>
                <p>These is the Assignments from </p>
                {contents}
            </div>
        );
     }


    async fetchEmployeeAssignments() {
        const response = await fetch('employee');
        const data = await response.json();
        this.setState({ assignmentviewmodels: data, loading: false });
    }
}