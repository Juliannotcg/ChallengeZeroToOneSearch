import React from 'react';
import {Redirect} from 'react-router-dom';
import {FuseUtils} from '@fuse';
import { ProductConfig } from 'app/main/product/ProductConfig';
import { CategoryConfig } from 'app/main/category/CategoryConfig';

const routeConfigs = [
    ProductConfig,
    CategoryConfig
];

const routes = [
    ...FuseUtils.generateRoutesFromConfigs(routeConfigs),
    {
        path     : '/',
        component: () => <Redirect to="/product"/>
    }
];

export default routes;
