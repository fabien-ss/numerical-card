package webService;

import jakarta.ws.rs.*;
import jakarta.ws.rs.core.*;

@Path("/example")
public class MyWebService {

    @GET
    @Path("/hello")
    @Produces(MediaType.TEXT_PLAIN)
    public String sayHello() {
        return "Hello, World!";
    }
}
