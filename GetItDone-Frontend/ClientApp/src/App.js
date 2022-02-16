import React, { Component } from 'react';
import { Route, Switch } from 'react-router';
import { Layout } from './components/Layout';
import { Login } from './components/Login';
import { Assignment } from './components/Assignment/Assignment';
import { ProjectManager } from './components/ProjectManager/ProjectManager';

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
                </Layout>
            </Switch>
        );
    }
}
