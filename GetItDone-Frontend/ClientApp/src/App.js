import React, { Component } from 'react';
import { Route, Switch } from 'react-router';
import { Layout } from './components/Layout';
import { Login } from './components/Login';
import { Assignment } from './components/Assignment/Assignment';
import { ProjectManager } from './components/ProjectManager/ProjectManager';
import { Company } from './components/Company/Company';
import { Customer } from './components/Customer/Customer';
import { Employee } from './components/Employees/Employee';
import { Contact } from './components/Contact/Contact';
import { Home } from './components/Home/Home';
import {ProfilePage} from './components/ProfilePage/ProfilePage'


import './custom.css'

export default class App extends Component {
    static displayName = App.name;


    render() {
        return (
            <Switch>
                <Route exact path='/' component={Login} />

                <Layout>
                    <Route path='/Assignment' component={Assignment} />
                    <Route path='/profile-page' component={ProfilePage} />
                    <Route path='/ProjectManager' component={ProjectManager} />
                    <Route path='/Company' component={Company} />
                    <Route path='/Customer' component={Customer} />
                    <Route path='/Employee' component={Employee} />
                    <Route path='/Contact' component={Contact} />
                    <Route path='/Home' component={Home} />

                </Layout>
            </Switch>
        );
    }
}
