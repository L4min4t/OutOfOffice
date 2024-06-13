import styled, {createGlobalStyle} from "styled-components";

export const cssValues = {
    textColor: "#262626",
    backgroundColor: "#BFD7EA",
    mainColor: "#91AEC1",
    interactiveColor: "#508CA4",
    interactivaOnMainColor: "#223c45",

    commonFontSize: "20px",
    titleFontSize: "36px",
    subTitleFontSize: "28px",
    fontFamily: "'Poppins', sans-serif",

    borderRadius: "5px",
    border: "2px solid #BFD7EA",
    borderInteractive: "2px solid #508CA4",

    itemsGap: "12px",
    blocksGap: "45px",

    widthAuthForm: "400px",

    headerHeight: "70px",
    footerHeight: "55px",

    boxShadow: "rgba(255, 255, 255, 0.1) 0px 1px 1px 0px inset, rgba(50, 50, 93, 0.25) 0px 50px 100px -20px, rgba(0," +
        " 0, 0, 0.3) 0px 30px 60px -30px;",
    hoverBoxShadow: "rgba(0, 0, 0, 0.35) 0px 5px 15px;",

}

const GlobalStyles = createGlobalStyle`
    @import url('https://fonts.googleapis.com/css2?family=Poppins:ital,wght@0,100;0,200;0,300;0,400;0,500;0,600;0,700;0,800;0,900;1,100;1,200;1,300;1,400;1,500;1,600;1,700;1,800;1,900&display=swap');

    * {
        font-family: ${cssValues.fontFamily};
        color: ${cssValues.textColor};
        font-size: ${cssValues.commonFontSize};
        font-weight: normal;
        text-decoration: none;
        padding: 0;
        margin: 0;

        border: none;
        cursor: default;
    }

    #root {
        min-height: 100vh;
    }

    html, body {
        min-height: 100vh;
        min-width: 100%;
    }
`;

export const PageContainer = styled.div`
    display: flex;
    flex-direction: column;

    width: 100%;
    min-height: 100vh;
`;

export const PageContentContainer = styled.div`
    display: flex;
    flex-direction: column;

    padding: 0 6%;

    width: calc(100% - 6% * 2);
    min-height: calc(100vh - ${cssValues.headerHeight} - ${cssValues.footerHeight});
`;

export default GlobalStyles;