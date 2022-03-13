package org.acme.DAOs;

import org.acme.Entities.Player;
import org.acme.Entities.Run;

import javax.enterprise.context.Dependent;
import javax.inject.Inject;
import javax.persistence.EntityManager;
import java.util.List;

@Dependent
public class RunDAO {
    @Inject
    EntityManager entityManager;

    // insert CRUD

    public List<Run> getAll() {
        return entityManager.createQuery("select e from Run e", Run.class).getResultList();
    }
}
