import styled from "styled-components";
import {cssValues} from "../../components/GlobalStyles";

export const Container = styled.div`
    width: ${cssValues.widthAuthForm};

    display: flex;
    flex-direction: column;
    row-gap: ${cssValues.blocksGap};
    margin: auto;
`;

export const Label = styled.h1`
    align-self: center;
    color: ${cssValues.mainColor};
    font-size: ${cssValues.titleFontSize};
    font-weight: 700;
`;

export const Form = styled.form`
    display: flex;
    flex-direction: column;
    row-gap: ${cssValues.itemsGap};

    width: 100%;
    height: fit-content;
`;

export const Input = styled.input`
    border: ${cssValues.border};
    border-radius: ${cssValues.borderRadius};
    padding: 6px 8px;

    transition: transform ease-out 0.2s;

    &:hover {
        cursor: pointer;
        transform: scale(1.01);
        border: ${cssValues.borderInteractive};
    }
`;

export const SubmitButton = styled.button`
    width: fit-content;
    height: fit-content;

    align-self: center;

    padding: 8px 20px;

    border-radius: ${cssValues.borderRadius};

    background: ${cssValues.mainColor};

    transition: transform ease-out 0.2s;

    &:hover {
        cursor: pointer;
        transform: scale(1.04);
        background: ${cssValues.interactiveColor};
    }
`;

export const SuggestContainer = styled.div`
    display: flex;
    flex-direction: column;
    align-self: center;
    align-items: center;
`;

export const SuggestText = styled.p`
`;

export const AuthLink = styled.a`
    font-weight: 600;
    background: none;
    border: none;
    color: ${cssValues.mainColor};
    width: fit-content;
    height: fit-content;
    transition: transform 0.2s ease-out, color 0.2s ease-out;

    &:hover {
        cursor: pointer;
        transform: scale(1.1);
        color: ${cssValues.interactiveColor};
    }
`;
