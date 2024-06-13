import React from "react";
import ReactDOM from "react-dom/client";
import axios from "axios";
import {HashRouter, Route, Routes} from "react-router-dom";

import App from "./App";
import LoginPage from "./pages/auth/login";
import RegisterPage from "./pages/auth/register";

import HomePage from "./pages/home";
import NotFoundPage from "./pages/not_found";
import EmployeesPage from "./pages/employees";
import ProjectsPage from "./pages/projects";
import LeaveRequestsPage from "./pages/leave_requests";
import ApprovalRequestsPage from "./pages/approval_requests";

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

                <Route index element={<HomePage/>}/>

                <Route path="/employees" element={<EmployeesPage/>}/>
                <Route path="/projects" element={<ProjectsPage/>}/>
                <Route path="/leave-requests" element={<LeaveRequestsPage/>}/>
                <Route path="/approval-requests" element={<ApprovalRequestsPage/>}/>
                
                <Route path="*" element={<NotFoundPage/>}/>
            </Route>
        </Routes>
    </HashRouter>
);