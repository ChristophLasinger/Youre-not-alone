package org.acme;

import org.acme.DAOs.PlayerDAO;
import org.acme.Entities.Player;

import javax.inject.Inject;
import javax.swing.text.html.parser.Entity;
import javax.ws.rs.GET;
import javax.ws.rs.Path;
import javax.ws.rs.Produces;
import javax.ws.rs.core.MediaType;
import java.util.List;

@Path("/hello")
public class GreetingResource {
    @Inject
    PlayerDAO playerDAO;

    @GET
    @Produces(MediaType.APPLICATION_JSON)
    public List<Player> hello() {
        return playerDAO.getAll();
    }
}