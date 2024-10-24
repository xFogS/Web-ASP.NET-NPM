import { useState } from 'react'
import Head from "../src/layout/HeadComponent"
import Navigation from "../src/layout/NavigationComponent"
import Header from "../src/layout/HeaderComponent"
import About from "../src/layout/AboutComponent"
import Projects from "../src/layout/ProjectsComponent"
import Signup from "../src/layout/SignupComponent"
import Contact from "../src/layout/ContactComponent"
import Footer from "../src/layout/FooterComponent"
function App() {
    return (
        <div id="page-top">
            <Head />
            <Navigation />
            <Header />
            <About />
            <Projects />
            <Signup />
            <Contact />
            <Footer />
        </div>
    );
}

export default App;
