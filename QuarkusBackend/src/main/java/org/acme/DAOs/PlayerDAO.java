package org.acme.DAOs;

import org.acme.Entities.Player;

import javax.enterprise.context.Dependent;
import javax.inject.Inject;
import javax.persistence.EntityManager;
import java.util.List;

@Dependent
public class PlayerDAO {
    @Inject
    EntityManager entityManager;

    // insert CRUD

    public List<Player> getAll() {
        return entityManager.createQuery("select e from Player e", Player.class).getResultList();
    }
}
