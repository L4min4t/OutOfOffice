import React from "react";
import {Outlet, useLocation} from "react-router-dom";

import GlobalStyles, {cssValues, PageContainer, PageContentContainer} from "./components/GlobalStyles";
import {AuthProvider} from "./context/AuthProvider";

import {ToastContainer} from "react-toastify";
import "react-toastify/dist/ReactToastify.css";
import Header from "./components/Header";
import Footer from "./components/Footer";

const App = () => {
    const location = useLocation();
    const noHeaderFooterPaths = ["/login", "/register", "*"];
    const showHeaderFooter = !noHeaderFooterPaths.includes(location.pathname);

    return (
        <>
            <GlobalStyles/>
            <ToastContainer
                position="top-right"
                autoClose={5000}
                hideProgressBar={false}
                newestOnTop={true}
                closeOnClick
                rtl={false}
                pauseOnFocusLoss
                draggable
                pauseOnHover
            />
            <AuthProvider>
                <PageContainer>
                    {showHeaderFooter ? <Header/> : <div style={{height: cssValues.headerHeight}}></div>}
                    <PageContentContainer>
                        <Outlet/>
                    </PageContentContainer>
                    {showHeaderFooter ? <Footer/> : <div style={{height: cssValues.footerHeight}}></div>}
                </PageContainer>
            </AuthProvider>
        </>
    );
};
export default App;