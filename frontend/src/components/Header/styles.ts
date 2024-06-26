import {cssValues} from "../GlobalStyles";
import styled from "styled-components";

export const HeaderContainer = styled.header`
    height: ${cssValues.headerHeight};

    display: flex;
    flex-direction: row;
    justify-content: space-between;
    align-items: center;

    padding: 0 6%;

    background: ${cssValues.mainColor};
`;

export const Logo = styled.a`
    color: ${cssValues.textColor};
    font-size: ${cssValues.titleFontSize};
    font-weight: 600;
    cursor: pointer;

    &:hover {
        color: ${cssValues.interactivaOnMainColor};
    }
`;

export const NavLink = styled.a`
    color: ${cssValues.textColor};
    font-size: ${cssValues.subTitleFontSize};
    font-weight: 600;
    cursor: pointer;
    text-align: center;
    align-self: center;

    &:hover {
        color: ${cssValues.interactivaOnMainColor};
        text-decoration: underline;
    }
`;

export const NavLinkContainer = styled.div`
    display: flex;
    flex-direction: row;
    justify-content: space-between;
    width: 50%;
    height: 100%;
`;

export const Greeting = styled.h2`
    font-size: ${cssValues.subTitleFontSize};
`;

export const UserName = styled.a`
    font-size: ${cssValues.subTitleFontSize};
    font-weight: 600;
    cursor: pointer;

    &:hover {
        color: ${cssValues.interactivaOnMainColor};
        text-decoration: underline;
    }
`;