import useAuthContext from "../../context/hooks";
import {Greeting, HeaderContainer, Logo, NavLink, NavLinkContainer, UserName} from "./styles";
import {useNavigate} from "react-router-dom";
import {useEffect} from "react";
import {toast} from "react-toastify";

const Header = () => {
    const {user, jwtTokens, logoutUser} = useAuthContext();
    const navigate = useNavigate();

    useEffect(() => {
        if (!user || !jwtTokens) {
            toast.error("Auth problems!")
            navigate("/login");
        }
    }, [user, jwtTokens]);

    return (
        <HeaderContainer>
            <Logo onClick={() => navigate("/")}>Out of Office</Logo>
            <NavLinkContainer>
                <NavLink onClick={() => navigate("/employees")}>employees</NavLink>
                {
                    user?.role.includes("Admin") || user?.role.includes("HR") ||
                    user?.role.includes("PM")
                    ? <NavLink onClick={() => navigate("/projects")}>projects</NavLink>
                    : <></> 
                }
                {
                    user?.role.includes("Admin") || user?.role.includes("HR") ||
                    user?.role.includes("PM")
                        ? <NavLink onClick={() => navigate("/leave-requests")}>leave<br/>requests</NavLink>
                        : <></>
                }
                <NavLink onClick={() => navigate("/approval-requests")}>approval<br/>requests</NavLink>
                {
                    user?.role.includes("Admin") || user?.role.includes("HR") ||
                    user?.role.includes("PM")
                        ? <NavLink onClick={() => navigate("/leave-requests")}>grant<br/>roles</NavLink>
                        : <></>
                }
            </NavLinkContainer>
            <Greeting>Hello, <UserName onClick={() => logoutUser()}>{user?.name}</UserName>!</Greeting>
        </HeaderContainer>);
}
export default Header;