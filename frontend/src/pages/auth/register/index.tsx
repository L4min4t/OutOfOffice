import React, {useContext} from "react";
import AuthContext from "../../../context/AuthContext";
import {useNavigate} from "react-router-dom";
import {AuthLink, Container, Form, Input, Label, SubmitButton, SuggestContainer, SuggestText} from "../styles";

const RegisterPage = () => {
    const {registerUser} = useContext(AuthContext)!;
    const navigate = useNavigate();

    return (
        <Container>
            <Label>Register</Label>
            <Form onSubmit={registerUser}>
                <Input type="text" name="email" placeholder="Email" required/>
                <Input type="text" name="username" placeholder="Name" required/>
                <Input type="password" name="password" placeholder="Password" required/>
                <SubmitButton type="submit">register</SubmitButton>
            </Form>
            <SuggestContainer>
                <SuggestText>Already have an account? </SuggestText>
                <AuthLink onClick={() => navigate("/login")}>Login</AuthLink>
            </SuggestContainer>
        </Container>
    );
};

export default RegisterPage;