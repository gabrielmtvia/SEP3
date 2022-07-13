package via.sep3.group2.persistance;

import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Repository;
import via.sep3.group2.repository.GenreRepository;
import via.sep3.group2.shared.GenreDTO;

import java.util.List;

@Repository
public class GenreDAO implements IGenreDAO{
    private GenreRepository genreRepository;
    @Autowired
    public GenreDAO(GenreRepository genreRepository) {
        this.genreRepository = genreRepository;
    }
    @Override
    public void createGenre(GenreDTO genreDTO){
        genreRepository.save(genreDTO);
    }
    @Override
    public List<GenreDTO> getAllGenre(){
       return genreRepository.findAll();
    }

}

