import styled from "styled-components";
import {cssValues} from "../GlobalStyles";

export const FooterContainer = styled.footer`
    display: flex;
    flex-direction: row;
    justify-content: center;
    align-items: center;


    height: ${cssValues.footerHeight};
    background: ${cssValues.mainColor};
`;