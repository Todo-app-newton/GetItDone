import React, { Component } from 'react';
import { Route, Switch } from 'react-router';
import { Layout } from './components/Layout';
import { Login } from './components/Login';
import { Assignment } from './components/Assignment/Assignment';
import { FetchData } from './components/FetchData';
import { Counter } from './components/Counter';
import { Employee } from './components/Employee/Employee';

import './custom.css'

export default class App extends Component {
    static displayName = App.name;



    render() {
        return (
            <Switch>
                <Route exact path='/' component={Login} />
                <Layout>
                    <Route path='/Assignment' component={Assignment} />
                    <Route path='/counter' component={Counter} />
                    <Route path='/fetch-data' component={FetchData} />
                    <Route path='/Employee' component={Employee} />
                </Layout>
            </Switch>
        );
    }
}
