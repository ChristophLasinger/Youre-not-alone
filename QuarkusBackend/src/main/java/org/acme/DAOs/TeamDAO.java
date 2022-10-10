package org.acme.DAOs;

import org.acme.Entities.Player;
import org.acme.Entities.Team;

import javax.enterprise.context.Dependent;
import javax.inject.Inject;
import javax.persistence.EntityManager;
import java.util.List;

@Dependent
public class TeamDAO {
    @Inject
    EntityManager entityManager;

    // insert CRUD

    public List<Team> getAll() {
        return entityManager.createQuery("select e from Team e", Team.class).getResultList();
    }
}
