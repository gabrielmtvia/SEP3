package via.sep3.group2.persistance;

import org.junit.jupiter.api.Test;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.boot.test.autoconfigure.orm.jpa.DataJpaTest;
import org.springframework.util.Assert;
import via.sep3.group2.repository.GenreRepository;
import via.sep3.group2.shared.GenreDTO;

import java.util.HashSet;
import java.util.Set;

import static org.junit.jupiter.api.Assertions.*;

@DataJpaTest
class GenreDAOTest {
  @Autowired
    GenreRepository genreRepository;
    @Test
    void createGenre() {
        GenreDTO genre= new GenreDTO("Math");
        genreRepository.save(genre);
        Assert.isTrue(genreRepository.findAll().size()==1);
        Assert.isTrue(genreRepository.findAll().contains(genre));

    }

    @Test
    void getAllGenre() {
        GenreDTO genre1= new GenreDTO("Math");
        genreRepository.saveAndFlush(genre1);
        GenreDTO genre2= new GenreDTO("History");
        genreRepository.saveAndFlush(genre2);
        Set<GenreDTO> genres=new HashSet<>();
        genres.add(genre1);
        genres.add(genre2);

        Assert.isTrue(genreRepository.findAll().size()==2);
        Assert.isTrue(genreRepository.findAll().containsAll(genres));

    }
}