import React, { Component } from 'react';
import { Collapse, Container, Navbar, NavbarBrand, NavbarToggler, NavItem, NavLink } from 'reactstrap';
import { Link } from 'react-router-dom';
import logo from './logo1.jpg';
import './NavMenu.css';

export class NavMenu extends Component {
  static displayName = NavMenu.name;

  constructor (props) {
    super(props);

    this.toggleNavbar = this.toggleNavbar.bind(this);
    this.state = {
        collapsed: true,
        LoginResponse: ''
    };
  }


    componentDidMount() {
        this.fetchLoggedInRole();  
    }


  toggleNavbar () {
    this.setState({
      collapsed: this.state.collapsed
    });
  }

    render() {


    return (
      <header>
        <Navbar className="navbar-expand-sm navbar-toggleable-sm ng-white border-bottom box-shadow mb-3" light>
            <img fluid
                className="img-nav"
                src={logo}
                alt="logo"
            />
            <NavbarToggler onClick={this.toggleNavbar} className="mr-2" />
                <Collapse className="d-sm-inline-flex flex-sm-row-reverse" isOpen={!this.state.collapsed} navbar>
                    <ul className="navbar-nav flex-grow">
                <NavItem style={{ padding: "1em" }}>
                    <NavLink tag={Link} className="text-dark" to="/profile-page">Profile page</NavLink>
                </NavItem>
                <NavItem style={{ padding: "1em" }}>
                    <NavLink tag={Link} className="text-dark" to="/Assignment" style={{ paddingLeft: "10em" }}>Assignments</NavLink>
                </NavItem>
                <NavItem style={{ padding: "1em" }}>
                            <NavLink tag={Link} className="text-dark" to="/fetch-data">Employees</NavLink>
                        </NavItem>

                 {loginRole.role === "ProjectManager" ?
                    <NavItem style={{ padding: "1em" }}>
                        <NavLink tag={Link} className="text-dark" to="/ProjectManager"> ProjectManagers</NavLink>
                    </NavItem> : null}

                <NavItem style={{ padding: "1em" }}>
                    <NavLink tag={Link} className="text-dark" to="/">Customers</NavLink>
                </NavItem>
                <NavItem style={{ padding: "1em" }}>
                    <NavLink tag={Link} className="text-dark" to="/">Contact</NavLink>
                </NavItem>
                <NavItem style={{ padding: "1em" }}>
                    <NavLink tag={Link} className="text-dark" to="/" style={{ marginLeft: "8em" }}>Sign Out</NavLink>
                </NavItem>

              </ul>
            </Collapse>
        </Navbar>
      </header>
    );
    }
    async fetchLoggedInRole() {
        const response = await fetch('api/authentication/Role');
        const data = await response.json();
        this.setState({ LoginResponse: data, loading: false });
    }
}
