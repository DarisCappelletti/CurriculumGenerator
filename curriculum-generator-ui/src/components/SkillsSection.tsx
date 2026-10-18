import { useState, useRef } from 'react';
import { IconTag } from './Icons';

interface Props {
  skills: string;
  onChange: (s: string) => void;
}

export function SkillsSection({ skills, onChange }: Props) {
  const [inputValue, setInputValue] = useState('');
  const inputRef = useRef<HTMLInputElement>(null);

  const tags = skills.split(',').map(s => s.trim()).filter(Boolean);

  const addTag = (value: string) => {
    const trimmed = value.trim();
    if (!trimmed) return;
    if (tags.includes(trimmed)) return;
    const newSkills = tags.length > 0 ? [...tags, trimmed].join(', ') : trimmed;
    onChange(newSkills);
  };

  const removeTag = (index: number) => {
    const newTags = tags.filter((_, i) => i !== index);
    onChange(newTags.join(', '));
  };

  const handleKeyDown = (e: React.KeyboardEvent<HTMLInputElement>) => {
    if (e.key === 'Enter' || e.key === ',') {
      e.preventDefault();
      addTag(inputValue);
      setInputValue('');
    } else if (e.key === 'Backspace' && inputValue === '' && tags.length > 0) {
      removeTag(tags.length - 1);
    }
  };

  const handleBlur = () => {
    if (inputValue.trim()) {
      addTag(inputValue);
      setInputValue('');
    }
  };

  return (
    <div className="section">
      <h2 className="section-title">
        <IconTag className="section-icon" size={20} />
        Skills
      </h2>
      <div className="tag-input-wrapper" onClick={() => inputRef.current?.focus()}>
        {tags.map((tag, i) => (
          <span key={i} className="tag">
            {tag}
            <button className="tag-remove" onClick={(e) => { e.stopPropagation(); removeTag(i); }}>&times;</button>
          </span>
        ))}
        <input
          ref={inputRef}
          type="text"
          value={inputValue}
          onChange={e => setInputValue(e.target.value)}
          onKeyDown={handleKeyDown}
          onBlur={handleBlur}
          placeholder={tags.length === 0 ? 'Aggiungi una skill e premi Invio...' : ''}
          className="tag-input"
        />
      </div>
    </div>
  );
}