public class ScoreModel : Model
{
    private int _score;

    private void Add()
    {
        _score++;
    }

    public override void SetData()
    {
        Add();

        _view.Display(_score);
    }
}
