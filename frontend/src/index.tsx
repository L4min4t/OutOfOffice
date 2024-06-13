import React from "react";
import ReactDOM from "react-dom/client";
import axios from "axios";
import {HashRouter, Route, Routes} from "react-router-dom";

import App from "./App";
import LoginPage from "./pages/auth/login";
import RegisterPage from "./pages/auth/register";

axios.defaults.xsrfCookieName = "csrftoken";
axios.defaults.xsrfHeaderName = "X-CSRFToken";

const root = ReactDOM.createRoot(
    document.getElementById('root') as HTMLElement
);
root.render(
    <HashRouter>
        <Routes>
            <Route path="/" element={<App/>}>
                <Route path="/login" element={<LoginPage/>}/>
                <Route path="/register" element={<RegisterPage/>}/>

                {/*<Route index element={<MainPage/>}/>*/}
                
                {/*<Route path="*" element={<NotFound/>}/>*/}
            </Route>
        </Routes>
    </HashRouter>
);