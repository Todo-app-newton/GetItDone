import React, { Component } from 'react';
import { Route, Switch } from 'react-router';
import { Layout } from './components/Layout';
import { Start } from './components/Start/Start';
import { FetchData } from './components/FetchData';
import { Counter } from './components/Counter';

import './custom.css'

export default class App extends Component {
  static displayName = App.name;

    render() {
        return (
            <Switch>
                <Route exact path='/' component={Login} />
                <Layout>
                    <Route path='/counter' component={Counter} />
                    <Route path='/fetch-data' component={FetchData} />
                </Layout>
            </Switch>
        );
    }
}
