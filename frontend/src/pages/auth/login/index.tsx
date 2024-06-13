import useAuthContext from "../../../context/hooks";
import React from "react";
import {useNavigate} from "react-router-dom";
import {AuthLink, Container, Form, Input, Label, SubmitButton, SuggestContainer, SuggestText} from "../styles";

const LoginPage = () => {
    const {loginUser} = useAuthContext();
    const navigate = useNavigate();

    return (
        <Container>
            <Label>Login</Label>
            <Form onSubmit={loginUser}>
                <Input type="text" name="email" placeholder="Email" required/>
                <Input type="password" name="password" placeholder="Password" required/>
                <SubmitButton type="submit">login</SubmitButton>
            </Form>
            <SuggestContainer>
                <SuggestText>Don't have an account? </SuggestText>
                <AuthLink onClick={() => navigate("/register")}>Register</AuthLink>
            </SuggestContainer>
        </Container>
    );
};


export default LoginPage;