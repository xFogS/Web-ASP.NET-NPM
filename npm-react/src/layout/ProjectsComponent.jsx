function ProjectsComponent() {
    return (
    /*< !--Projects-- >*/
        <section className="projects-section bg-light" id="projects">
            <div className="container px-4 px-lg-5">
                {/*<!-- Featured Project Row-->*/}
                <div className="row gx-0 mb-4 mb-lg-5 align-items-center">
                    <div className="col-xl-8 col-lg-7"><img className="img-fluid mb-3 mb-lg-0" src="./assets/img/bg-masthead.jpg" alt="..." /></div>
                    <div className="col-xl-4 col-lg-5">
                        <div className="featured-text text-center text-lg-left">
                            <h4>Shoreline</h4>
                            <p className="text-black-50 mb-0">Grayscale is open source and MIT licensed. This means you can use it for any project - even commercial projects! Download it, customize it, and publish your website!</p>
                        </div>
                    </div>
                </div>
               {/* <!-- Project One Row-->*/}
                <div className="row gx-0 mb-5 mb-lg-0 justify-content-center">
                    <div className="col-lg-6"><img className="img-fluid" src="./assets/img/demo-image-01.jpg" alt="..." /></div>
                    <div className="col-lg-6">
                        <div className="bg-black text-center h-100 project">
                            <div className="d-flex h-100">
                                <div className="project-text w-100 my-auto text-center text-lg-left">
                                    <h4 className="text-white">Misty</h4>
                                    <p className="mb-0 text-white-50">An example of where you can put an image of a project, or anything else, along with a description.</p>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
                {/*<!-- Project Two Row-->*/}
                <div className="row gx-0 justify-content-center">
                    <div className="col-lg-6"><img className="img-fluid" src="./assets/img/demo-image-02.jpg" alt="..." /></div>
                    <div className="col-lg-6 order-lg-first">
                        <div className="bg-black text-center h-100 project">
                            <div className="d-flex h-100">
                                <div className="project-text w-100 my-auto text-center text-lg-right">
                                    <h4 className="text-white">Mountains</h4>
                                    <p className="mb-0 text-white-50">Another example of a project with its respective description. These sections work well responsively as well!</p>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </section>
    )
}

export default ProjectsComponent;